using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

[ExecuteAlways]
public class AStarFindPath : MonoBehaviour
{
    public class Point
    {
        public Point Parent;
        public int X;
        public int Y;
        
        public bool IsObstacle => Tile.RoadType == RoadType.Obstacle;

        public RoadTile Tile;
        
        public float F => G + H;
        public float H;
        public float G;
    }
    
    public Transform root;
    public GameObject tempRoad;

    public Vector2 _mapSize = new Vector2(10, 10);
    private List<GameObject> _allRoads = new List<GameObject>();
    private Point[,] _map = new Point[10, 10];
    
    [Button("创建路点")]
    public void CreateRoads()
    {
        ClearRoads();

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                // var road = GameObject.CreatePrimitive(PrimitiveType.Cube);
                var road = Instantiate(tempRoad, root, true);
                road.transform.position = new Vector3(i, 0, j);
                road.name = i + "_" + j;
                road.AddComponent<RoadTile>();
                _allRoads.Add(road);
                _map[i, j] = new Point()
                {
                    Tile = road.GetComponent<RoadTile>(),
                    X = i,
                    Y = j
                };
            }
        }
    }

    [Button("清除路点")]
    public void ClearRoads()
    {
        foreach (var road in _allRoads)
        {
            GameObject.DestroyImmediate(road);
        }
        _allRoads.Clear();
    }

    [Button("刷新状态")]
    public void RefreshColor()
    {
        foreach (var road in _allRoads)
        {
            road.GetComponent<RoadTile>().RoadType = RoadType.Empty;
            // road.GetComponent<RoadTile>().RefreshColor();
        }
    }

    [Button("寻路")]
    public void StartFindPath()
    {
        Point start = null, end = null;
        foreach (var road in _map)
        {
            if (road.Tile.RoadType == RoadType.Start)
            {
                start = road;
            }
            
            if (road.Tile.RoadType == RoadType.End)
            {
                end = road;
            }
        }

        var list = TryFindPath(start, end);
        foreach (var point in list)
        {
            if (point.Tile.RoadType != RoadType.Start && point.Tile.RoadType != RoadType.End)
            {
                point.Tile.RoadType = RoadType.PathPoint;
            }
        }
    }
    
    public List<Point> TryFindPath(Point start, Point end)
    {
        if (start == null || end == null)
        {
            Debug.LogError("起点/终点为空，没有路径");    
        }
        
        var openList = new List<Point>();
        var closeList = new List<Point>();

        openList.Add(start);
        
        while (openList.Count > 0)
        {
            // 开启列表中 F最小的点
            var point = GetMinFPoint(openList);
            closeList.Add(point);
            openList.Remove(point);
            
            // 邻居点，过滤一下，加到开启列表里
            var surrounds = GetSurroundPoints(point);
            foreach (var surround in surrounds)
            {
                if (surround.Tile.RoadType == RoadType.Obstacle)
                {
                    continue;
                }
                
                // 在关闭列表里 不加
                if (closeList.Contains(surround))
                {
                    continue;
                }
                
                // 不在开启列表里
                if (!openList.Contains(surround))
                {
                    //设置父节点，更新F值，然后加到openList里    
                    surround.Parent = point;
                    surround.G = CalculateG(surround, point);
                    surround.H = CalculateH(surround, end);
                    openList.Add(surround);
                }
                
                if (openList.Contains(surround))
                {
                    // 更新G值，这个点G值更小，代表路径更短
                    var newG = CalculateG(surround, point);
                    if (newG < surround.G)
                    {
                        surround.G = newG;
                        surround.Parent = point;
                    }
                }
            }
            
            if (closeList.Contains(end))
            {
                return GatherPaths(end);
            }
        }

        return null;
    }

    public Point GetMinFPoint(List<Point> openList)
    {
        openList.Sort((a, b) =>
        {
            return a.F >= b.F ? 1 : -1;
        });
        
        return openList[0];
    }

    public List<Point> GetSurroundPoints(Point center)
    {
        var list = new List<Point>();
        // 上
        _TryInsertPoint(center.X - 1, center.Y, list);
        
        // 下
        _TryInsertPoint(center.X + 1, center.Y, list);
        
        // 右
        _TryInsertPoint(center.X, center.Y + 1, list);
        
        // 左
        _TryInsertPoint(center.X, center.Y - 1, list);
        
        // 左上角
        _TryInsertPoint(center.X - 1, center.Y - 1, list);

        // 右上角
        _TryInsertPoint(center.X - 1, center.Y + 1, list);
        
        // 左下角
        _TryInsertPoint(center.X + 1, center.Y - 1, list);
        
        // 右下角
        _TryInsertPoint(center.X + 1, center.Y + 1, list);
        
        return list;
    }

    private void _TryInsertPoint(int x, int y, List<Point> list)
    {
        if (x < 0 || x >= _mapSize.x)
        {
            return;
        }
        
        if (y < 0 || x >= _mapSize.y)
        {
            return;
        }

        try
        {
            list.Add(_map[x, y]);
        }
        catch (Exception e)
        {
            Console.WriteLine("x = " + x + " y = " + y);
        }
    }
    
    public List<Point> GatherPaths(Point end)
    {
        var list = new List<Point>();
        var curPoint = end;
        while (curPoint.Parent != null)
        {
            list.Add(curPoint);
            curPoint = curPoint.Parent;
        }

        return list;
    }

    // G值 从起点到当前节点的实际代价，通常表示为累计的路径长度或代价
    // 当前点和父节点距离，在累计上父节点的G值
    public float CalculateG(Point cur, Point parent)
    {
        return Vector2.Distance(new Vector2(cur.X, cur.Y), new Vector2(parent.X, parent.Y)) + parent.G;
    }

    // 启发式估计 从当前节点到终点的估计代价，通常使用启发式函数来估计
    // 曼哈顿算法，就是x差和y差
    // 欧几里得距离 两点的距离
    public float CalculateH(Point cur, Point end)
    {
        // 欧几里得距离
        // return Vector2.Distance(new Vector2(cur.X, cur.Y), new Vector2(end.X, end.Y));
        // 曼哈顿距离
        return Math.Abs(cur.X - end.X) + Math.Abs(cur.Y - end.Y);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
