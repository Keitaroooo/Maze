using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject Wall;
    GameObject Wallgen;

    //座標
    class Point
    {
        public int x, z;
    }

    //座標の値を設定
    Point newPoint(int x, int z)
    {
        Point a = new Point();
        a.x = x;
        a.z = z;
        return a;
    }

    Point[] node = new Point[(HomeDirector.width-2) * (HomeDirector.height-2) / 4];// 未開発の（壁が伸びていない）柱のリスト(配列の数は大体)
    int nodeend = 0; // nodesリストの番号
    Point[] path = new Point[(HomeDirector.width - 2) * (HomeDirector.height - 2) / 4]; // 探索した柱のリスト（スタック）
    int pathend = 0; // pathリストの番号
 
    // リストに新たな要素を追加(nodes)
    void insert_node(Point c)
    {
        node[nodeend] = c;
        nodeend++;
    }
    // リストに新たな要素を追加(path)
    void insert_path(Point c)
    {
        path[pathend] = c;
        pathend++;
    }

    // nodesリストの任意の要素を取り出す
    Point remove_node(int k)
    {
        Point a;
        a = node[k]; // 取り出す
        for (int i = k; i < nodeend - 1; i++) // 取り出したぶん詰める
        {
            node[i] = node[i + 1];
        }
        nodeend--;
        return a;
    }

    // pathリストの†末尾†の要素を取り出す
    Point remove_path()
    {
        Point a;
	    a = path[pathend - 1]; // 取り出す
        pathend--;
        return a;
    }

    // リスト総当たり検索(node)
    int search_node(Point c)
    {
        for (int i = 0; i <= nodeend - 1; i++)
        {
            if ((node[i].x == c.x) && (node[i].z == c.z))
                return i;
        }
        return -1;//引数が配列nodeに含まれない
    }

    // リスト総当たり検索(path)
    int search_path(Point c)
    {
        for (int i = 0; i <= pathend - 1; i++)
        {
            if ((path[i].x == c.x) && (path[i].z == c.z))
                return i;
        }
        return -1;//引数がpath[]に含まれない
    }

    // 上下左右シャッフル
    void shuffle(Point[] direction)
    {
        int j;
        Point tmp;
        for (int i = 0; i < 4; i++)
        {
            j = Random.Range(0, 4);
            tmp = direction[i];
            direction[i] = direction[j];
            direction[j] = tmp;
        }
    }

    // 柱を探索（再帰）
    int choose_node(Point c)
    {
        int s, r;
        Point p1, p2;
        Point[] direction = new Point[4] { newPoint(0, 2), newPoint(0, -2), newPoint(2, 0), newPoint(-2, 0) }; // 壁を伸ばす方向

        if (search_path(c) != -1)// cが探索済の時 
        {  
            return 1; // 生成失敗
        }
        else//cが未探索or壁の時
        {
            insert_path(c); // pathに追加
            s = search_node(c);

            if (s != -1)// cが未探索の時
            { 
                remove_node(s); // nodeから消す

                // 上下左右のいずれかに壁を伸ばす
                shuffle(direction);
                for (int i = 0; i < 4; i++)
                {
                    r = choose_node(newPoint(c.x + direction[i].x, c.z + direction[i].z));
                    if (r == 0) return r;
                }

                //どこにも伸ばせない場合一個前に戻る
                insert_node(remove_path());
                return 1;
            }

            else// cがすでに壁の時
            { 
                // pathリストの末尾から一つずつ取り出し壁を作る
                p2 = remove_path();
                do
                {
                    p1 = p2;
                    p2 = remove_path();
                    makewall((p1.x + p2.x) / 2, 1, (p1.z + p2.z) / 2);
                } while (pathend!=0);
                return 0;
            }
        }
    }

    //壁生成
    void makewall(int x,int y, int z)
    {
        GameObject OuterWall = Instantiate(Wall) as GameObject;
        OuterWall.transform.position = new Vector3(x,y,z);
        if (x % 2 == 1) OuterWall.transform.localScale = new Vector3(1.9f, 2, 0.1f);
        if (z % 2 == 1) OuterWall.transform.localScale = new Vector3(0.1f, 2, 1.9f);
    }

    // 迷路の自動生成
    void make_maze(int width, int height)
    {

        while (nodeend!=0)
        {
            choose_node(node[Random.Range(0,nodeend)]);
        }

        // 外壁
        for (int i = 0; i <= width; i++)
        {
            makewall(i, 1, 0);
            makewall(i, 1, height);
        }
        for (int i = 0; i <= height; i++)
        {
            makewall(0, 1, i);
            makewall(width, 1, i);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        int i, j;

        // 柱リストの作成
        for (i = 2; i <= HomeDirector.width - 2; i+= 2)
        {
            for (j = 2; j <= HomeDirector.height - 2; j += 2)
            {
                insert_node(newPoint(i, j));
                makewall(i, 1, j);
            }
        }

        // 迷路の自動生成
        make_maze(HomeDirector.width, HomeDirector.height);

    }



       


    // Update is called once per frame
    void Update()
    {
        
    }
}
