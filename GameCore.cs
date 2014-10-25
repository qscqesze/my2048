    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace My2048
    {
        class GameCore
        {
            public static int[,] map = new int[4,4];
            static int[] empty_list = new int[16];
            static int empty_count;
            static int flag;                     //是否结束子循环的代码
            static int change;                   //检测布局是否改变。
            static int[] dir_x = {1,-1,0,0};    //进行移动的方向
            static int[] dir_y = {0,0,1,-1};
            static int[,] mergeSet ;           //控制每个单元是否合并过的合并开关，每个格子每回合只能合并一次
            public static int score;
            static Random rand = new Random();
            /*
            to : 0 上 1 下 2 左 3 右
            */

            public static void merge_cell(int i,int j,int to)
            {
                int tmp_x = i + dir_x[to];
                int tmp_y = j + dir_y[to];
                if(0==map[i,j])//如果为0的话，就转移
                {
                    map[i,j] = map[tmp_x,tmp_y];
                    map[tmp_x,tmp_y] = 0;
                    change = 1;
                }
                else if(map[i,j]==map[tmp_x,tmp_y]&&mergeSet[i,j]!=1)//如果两者相等且都有格子的话
                {
                    map[i,j]+=map[i,j];
                    score = score + map[i, j];
                    mergeSet[i,j] = 1;
                    map[tmp_x,tmp_y] = 0;
                    change = 1;
                    flag = 0;
                }
                else flag = 0;
            }
            public static int move_merger(int to)
            {
                int i,j,k;
                mergeSet = new int[4, 4];
                change = 0;
                if(0==to)
                {
                    for(k=1;k<4;k++)
                    {
                        for(j=0;j<4;j++)
                        {
                            if(0==map[k,j]) continue;
                            flag = 1;
                            for(i=k-1;i>=0&&flag>0;i--)
                            {
                                merge_cell(i,j,to);
                            }
                        }
                    }
                }
                else if(1==to)
                {
                    for(k=3;k>=0;k--)
                    {
                        for(j=0;j<4;j++)
                        {
                            if(0==map[k,j]) continue;
                            flag = 1;
                            for(i=k+1;i<4&&flag>0;i++)
                            {
                                merge_cell(i,j,to);
                            }
                        }
                    }
                }
                else if(2==to)
                {
                    for(k=1;k<4;k++)
                    {
                        for(i=0;i<4;i++)
                        {
                            if(0==map[i,k]) continue;
                            flag = 1;
                            for(j=k-1;j>=0&&flag>0;j--)
                            {
                                merge_cell(i,j,to);
                            }
                        }
                    }
                }
                else if(3==to)
                {
                    for(k=3;k>=0;k--)
                    {
                        for(i=0;i<4;i++)
                        {
                            if(0==map[i,k]) continue;
                            flag = 1;
                            for(j=k+1;j<4&&flag>0;j++)
                            {
                                merge_cell(i,j,to);
                            }
                        }
                    }
                }
                return change;
            }
            public static int update_map()
            {
                int num_rand;
                int i,j;
                empty_count = 0;
                for(i=0;i<4;i++)
                {
                    for(j=0;j<4;j++)
                    {
                        if(map[i,j]==0)
                        {
                            empty_list[empty_count] = i*4 + j;
                            empty_count++;
                        }
                    }
                }
                if(empty_count>0)
                {
                    num_rand = rand.Next()%empty_count;
                    int tmp_x = empty_list[num_rand]/4;
                    int tmp_y =  empty_list[num_rand]%4;
                    if ((rand.Next()%10)>0) num_rand = 2;
                    else num_rand = 4;
                    map[tmp_x,tmp_y] = num_rand;
                    empty_count--;
                }
                return 0;
            }
            public static bool is_win()
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (map[i, j] == 2048) return true;
                    }
                }
                return false;
            }
        }
    }
