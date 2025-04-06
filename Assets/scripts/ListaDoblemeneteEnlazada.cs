using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEditor.Experimental.GraphView;
public class ListaDoblemeneteEnlazada<T> : MonoBehaviour
{

    public Node<T> lastNode;
    public Node<T> Head;
    public int count = 0;

    public virtual void Añade(T value)
    {
        Node<T> Newnode = new Node<T>(value);
        count++;
        if (Head == null)
        {
            lastNode = Newnode;
            Head = Newnode;
            return;
        }
        lastNode.SetNext(Newnode);   
        Newnode.setPrev(lastNode);   
        lastNode = Newnode;
    }

    public virtual void Remove(T objective)
    {
        Node<T> nodeToRemove = Seek(objective); 

        if (nodeToRemove == null)
        {
            print("No se encontró el elemento para eliminar.");
            return;
        }

        if (nodeToRemove == Head) 
        {
            Head = nodeToRemove.Next;
            if (Head != null)
            {
                Head.setPrev(null);
            }
        }
        else if (nodeToRemove == lastNode) 
        {
            lastNode = nodeToRemove.Prev;
            if (lastNode != null)
            {
                lastNode.SetNext(null);
            }
        }
        else 
        {
            nodeToRemove.Prev.SetNext(nodeToRemove.Next);
            nodeToRemove.Next.setPrev(nodeToRemove.Prev);
        }
        count--; 
    }
    public Node<T> Seek(T objective, Node<T> _head=null, int deep = 0)//Busca al mismo objetivo 
    {
        if (Head == null || deep >= count)
        {
            print("No hay elemento en la lista o nose enconro el que buscas");
            return null;
        }
        if (_head == null) { _head = Head; }
        if (_head.Value.Equals(objective))
        {
            print("Elemeneto encontrado: " + _head.Value.ToString());
            print("Se encontro en la posicion: " + deep);
            return _head;
        }
        else
        {
            return Seek(objective, _head.Next, deep + 1);
        }
    }
    public virtual void ReadAll(Node<T> _head = null, int deep = 0)
    {
        if (Head == null || deep >= count) return;
        if (_head == null)
        {
            _head = Head;
        }
        print("Musica numero: " + deep + " " + _head.Value.ToString());
        print("Siguiente");
        ReadAll(_head.Next, deep + 1);
    }
}
