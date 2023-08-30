namespace Dynamic_Array
{
    /* 
       Author  : MINmin
       Date    : 2023. 08. 29
       Name    : List(동적배열)구현해보기 1
       Lecture : 인프런 [C#과 유니티로 만드는 MMORPG 게임 개발 시리즈] Part2: 자료구조와 알고리즘
                 섹션1. 선형 자료 기초 : 동적 배열 구현 연습
    */ 
    class Program
    {
        static void Main(string[] args)
        {
            MyDynamicArray<int> myArray = new MyDynamicArray<int>();

            for (int i = 1; i <= 10; i++)
                myArray.Add(i);

            myArray.Insert(7, 11);
            myArray.RemoveAt(7);

            Console.WriteLine(myArray[9]);
        }
    }
}