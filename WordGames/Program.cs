using System;

namespace WordGames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] startListData = new string[] { "开始游戏", "关于游戏", "退出游戏" };
            //创建开始界面的选项列表
            OptionList startGameList = new OptionList(startListData);
            //注册开始界面选项的方法
            startGameList.AddOptionEffect(StartOption);
            //显示
            startGameList.ShowList();
            //获取输入
            int input = int.Parse(Console.ReadLine());
            //将输入传进去
            startGameList.Choose(input);
            //阻塞函数，防止一闪而过
            Console.Read();
        }
        static void StartOption(int choose)
        {
            switch (choose)
            {
                case 1:StartGame();
                    break;
                case 2:AboutGame();
                    break;
                case 3:QuitGame();
                    break;
            }
        }

        static void QuitGame()
        {
            //待做
        }

        static void AboutGame()
        {
            //待做
        }

        static void SceneOption(int choose)
        {
            switch (choose)
            {
                case 1:
                    Console.WriteLine("你因为乱跑被抓住，游戏结束");
                    break;
                case 2:
                    Console.WriteLine("没有店铺辣");
                    break;
            }
        }
        /// <summary>
        /// 这个函数是执行开始游戏
        /// </summary>
        static void StartGame()
        {
            //进入场景，创建场景的选项列表
            OptionList sceneList = new OptionList(new string[] {"随便逛逛","查看店铺" });
            //注册场景的选项列表
            sceneList.AddOptionEffect(SceneOption);
            //显示列表
            sceneList.ShowList();
            //获取输入
            int input = int.Parse(Console.ReadLine());
            //将输入传进去
            sceneList.Choose(input);
        }
    }
    class OptionList
    {
        string[] list;
        Action<int> optionEffect;
        public OptionList(string[] strs)
        {
            list = strs;
        }
        public void ShowList()
        {
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(i + 1 + "." + list[i]);
            }
        }
        public void Choose(int num)
        {
            optionEffect.Invoke(num);
        }
        public void AddOptionEffect(Action<int> action)
        {
            optionEffect += action;
        }
    }

}
