public class elfList
{
    class Node<D>
    {
        public int elfNumber;
        public int totalCalories;

        public Node<D> next;

        public static Node<int> BuildNode(int data, int data2)
        {
            Node<int> node = new Node<int>();
            node.elfNumber = data;
            node.totalCalories = data2;
            return node;
        }

        public static void PrintLinkedList(Node<D> head)
        {
            while (head != null)
            {
                Console.Write(head.elfNumber + ":" + head.totalCalories + " , ");
                head = head.next;
            }

            Console.WriteLine("END");
        }
    }

    Node<int> head;
    Node<int> tail;

    public elfList()
    {
        this.head = null;
        this.tail = null;
    }

    public void addItem(int data1, int data2 )
    {
        Node<int> myNode = Node<int>.BuildNode(data1, data2);
        myNode.next = null;

        if (this.head == null || this.tail == null)
        {
            this.head = myNode;
            this.tail = myNode;
        }
        else
        {
            Node<int> currHead = this.head;
            Node<int> previous = null;

            while (currHead != null)
            {
                if(currHead.next == null) 
                { 
                    currHead.next = myNode;
                    break;
                }
                else if (myNode.totalCalories > currHead.totalCalories &&
                         previous == null )
                {
                    // Append on head
                    Node<int> tmp = currHead;
                    myNode.next = currHead;
                    this.head = myNode;
                    break;
                }
                else if (myNode.totalCalories > currHead.totalCalories &&
                         previous != null &&
                         myNode.totalCalories < previous.totalCalories  )
                {
                    previous.next = myNode;
                    myNode.next = currHead;
                    break;
                }
                previous = currHead;
                currHead = currHead.next;
            }
        }
    }

    public void PrintLinkedList()
    {
        Node<int>.PrintLinkedList(this.head);
    }

    public int getTopCalorie(int number)
    {
        Node<int> currHead = this.head;
        int totalCalories=0;
        for (int i=0; i<number; i++)
        {
            totalCalories += currHead.totalCalories;
            currHead = currHead.next;
        }
        return totalCalories;
    }
}