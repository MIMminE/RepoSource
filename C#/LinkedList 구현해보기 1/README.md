프로젝트 개요 
1. 프로젝트 이름 : MyLinkedList
2. 프로젝트 목표 : LinkedList 구조 이해를 위해 추가/삭제 기능 구현해보기
3. 주요 기술 및 개념
    ○ LinkedList 자료 구조  
    ○ LinkedList 개념에서 사용되는 node의 구현방법과 사용방법


프로그램 구조
클래스 기본 골격
< MylistNode >  

연결 리스트의 각 데이터를 저장하는 단위로 사용되며, 자기 자신의 데이터와 자신 앞 뒤의 데이터들에 대한 주소를 저장하고 있어야 한다.

class MylistNode<T>
{
    public T Data { get; set; }
    public MylistNode<T>? Next = null;
    public MylistNode<T>? Prev = null;
}
특이한 점은 자기 자신 클래스를 멤버변수로 가지고 있다는 점이다.
단순하게 보면 이해하기 어렵지만 인스턴스 자체를 가지고 있는 것이 아니라 인스턴스의 주소를 가지고 있다라고 이해하면 편하다. (클래스는 참조 타입으로 동작하기 때문에)


< MyList >  

실제 연결리스트 클래스이다.

MylistNode 클래스의 인스턴스들을 가지며 시작 노드와 끝 노드를 기억하고 있어야 한다.

이는 연결리스트 자료구조의 특징이다. 
시작 노드와 끝 노드만을 최신화하며 기억하고 있으면 각 노드들이 자기 다음 노드를 기억하고 있기에
모든 데이터들에 대한 접근이 순차적으로 가능하게 된다.
(덕분에 탐색 속도는 조금 느리다)


클래스 멤버 변수를 살펴보면 아래와 같이 시작 노드, 끝 노드, 전체 노드의 개수만을 기억하고 있다.

class MyList<T>
{
    private MylistNode<T>? _First = null;
    private MylistNode<T>? _Last = null;
    private int _Count = 0;
}
구현한 메소드로는 아래와 같이 두 가지가 있다.

연결리스트의 마지막에 원소를 추가하는 AddLast
입력으로 주어진 노드를 연결리스트에서 제거하는 Remove




실제 LinkedList 메소드 살펴보기
제공해주는 LinkedList의 AddLast 메소드 구조를 살펴보면

public LinkedListNode<T> AddLast(T value){}
public void AddLast(LinkedListNode<T> node){}
메소드 오버로딩으로 두 가지 버젼을 사용할 수 있다. 

살펴보면 두 방식 모두 LinkedListNode 타입으로 관리를 하는 것을 확인할 수 있다. 



public bool Remove(T value){}
public void Remove(LinkedListNode<T> node){}
Remove 메소드도 마찬가지로 노드를 입력하는 방식과 값을 입력하는 방식이 오버로딩되어 있다.



내부적으로 로직을 살펴보면 노드를 직접 입력해주는 방식은 해당 노드를 추가하는 방식이고
값을 입력해주는 방식은 해당 값으로 노드를 만들어서 추가하는 방식이다. 
결국에는 같은 결과를 가져오지만 사용자의 편의성을 위해 두 방식을 구현해둔것으로 보인다. 

이번 프로젝트에서는 네 가지 메소드를 모두 구현해보았다.
AddLast
노드를 반환하는 AddLast 부터 구현해보면

public MylistNode<T> AddLast(T item)
{
    MylistNode<T> newNode = new MylistNode<T>();
    newNode.Data = item;     1️⃣

    if (_First == null)      2️⃣
    {
        _First = newNode;
        _Last = newNode;
    }
    else if (_Last != null)  3️⃣
    {
        newNode.Prev = _Last;
        _Last.Next = newNode;
        _Last = newNode;

    }
    _Count++;
    return newNode;          4️⃣
}


1️⃣ 메소드 내부에서 노드를 생성하여 Data 값을 입력값으로 채운다.

2️⃣ 연결리스트의 첫번째 노드가 없다면 해당 리스트에 아무 노드가 없는것이며, 새로 들어온 노드가 첫번째이자 마지막 노드가 된다.

3️⃣ 연결리스트의 마지막 노드가 있다면 새로 입력된 노드를 마지막 노드로 변경하는 작업을 해준다.

연결리스트의 마지막 노드를 갱신해주는 과정은 아래와 같다.
1. 새로운 노드는 연결리스트의 마지막 노드가 될 것이므로 기존 마지막 노드의 Next에 새로운 노드의 주소가 입력된다.
2. 새로운 노드의 이전 노드는 기존 마지막 노드가 될 것이므로 새로운 노드의 Prev는 기존의 마지막 노드의 주소이다.
3. 마지막으로 현재 연결리스트의 마지막 노드를 새로 추가된 노드로 변경해준다.
4️⃣ 메소드 내부에서 만들어진 노드를 반환한다. 이 노드를 보관하여 삭제, 수정, 비교 등이 가능하다.



노드를 반환하지 않는 AddLast는 

public void AddLast(MylistNode<T> node)
{
    if(_First == null)
    {
        _First = node;
        _Last = node;
    }
    else if(_Last != null)
    {
        node.Prev = _Last;
        _Last.Next = node;
        _Last = node;
    }
    _Count++;
}
전체적인 로직은 동일하며 다른 점은 입력으로 들어온 노드를 가지고 작업을 한다는 것이 차이점이다.





Remove
반환이 없는 Remove를 보면

public void Remove(MylistNode<T> node)
{
    node.Prev.Next = node.Next;
    node.Next.Prev = node.Prev;
    _Count--;
}
간단하게 입력으로 들어온 노드를 기준으로 앞, 뒤 노드를 변경해주면 된다. 

주의해야한 점은 입력으로 주어진 노드가 연결 리스트에 입력으로 주어진 노드와 동일해야 정상적인 삭제가 가능하다.
이는, 노드의 Data가 같다고 같은 노드라는 점이 아니다.
AddLast 등을 통해 연결리스트에 입력할 때 반환받는 노드를 입력해줘야 해당 노드 삭제가 정상적으로 이루어 진다.

이는 각 노드는 클래스의 인스턴스이므로 참조타입으로 힙 영역에 적재되며 주소로써 기억이 되므로 인스턴스 내부의 값이 모두 동일하더라도 동일 노드로 취급되지 않는다.




bool 타입의 T 타입 매개변수를 입력으로 받는 Remove의 구현을 보면

public bool Remove(T item)
{
    MylistNode<T> thisNode = _First;     1️⃣
    while (thisNode != _Last) {          2️⃣
        if (thisNode.Data.Equals(item))  3️⃣
        {
            thisNode.Prev.Next = thisNode.Next;  4️⃣
            thisNode.Next.Prev = thisNode.Prev;  5️⃣
            _Count--;
            return true;
        }
        thisNode = _First.Next;    6️⃣
    }
    return false;
}


1️⃣ ~ 2️⃣ 입력으로 주어진 데이터와 같은 값을 가진 노드를 찾기 위한 준비 과정이다.

3️⃣ 현재 노드의 데이터와 입력으로 주어진 item이 같은지를 본다. (아래에서 조금 더 깊게 살펴본다!)

4️⃣ ~ 5️⃣ 지워야할 노드를 찾았다면 해당 노드의 앞, 뒤 노드를 변경해준다.

6️⃣ 타겟이 되는 노드를 찾기 위해 노드를 한 칸씩 이동하며 반복한다.



해당 Remove의 문제는 찾고자 하는 값이 여러개일때, 연결리스트의 앞 부분에 있는 데이터만을 찾아 삭제한다는 것이다. 



동일성과 동등성
변수나 값을 비교할 때 사용되는 == 연산자는 primitive 타입 자료형(int,float,bool 등)의 값에 대한 비교이다. 이것을 
참조 자료형(클래스,인터페이스,구조체 등)에게 ==를 사용하는 것은 참조형 변수가 저장하고 있는 메모리의 동일성을 확인하는 것이다. 

제너릭 T 타입은 기본 자료형뿐 아니라 참조 자료형 타입이 될 수도 있다. 그렇기에 연산자의 사용의도가 어긋날 수도 있음에 제너릭 타입에서는 == 연산자를 허용하지 않는다.
대신 모든 오브젝트에 존재 하는 Equals 메소드를 통해 비교 기능을 구현할 수 있다.

Equals은 오브젝트의 동등성을 비교하는 메소드이며 모든 자료형들은 오브젝트 클래스를 참조하고 있으므로 모든 자료형에 사용이 가능하다. 


LinkedList의 실제 메소드는 어떤 식으로 동등성을 다루는 지 확인해보니

public LinkedListNode<T>? Find(T value)
{
    LinkedListNode<T>? node = head;
    EqualityComparer<T> c = EqualityComparer<T>.Default; 1️⃣
    if (node != null)
    {
        if (value != null)
        {
            do
            {
                if (c.Equals(node!.item, value)) 2️⃣
                {
                    return node;
                }
                node = node.next;
            } while (node != head);
        }
        else
        {
            do
            {
                if (node!.item == null)
                {
                    return node;
                }
                node = node.next;
            } while (node != head);
        }
    }
    return null;
}
EqualityComparer 클래스를 이용하여 입력 값과 같은 노드를 탐색하고 있었다.

해당 클래스는 객체 비교를 위한 추상 도우미 클래스이며, 해당 클래스를 통해 오브젝트의 동등성을 확인하고 있었다.