using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class gameManagerr : MonoBehaviour
{
    ListaDoblemeneteEnlazada<string> listadoble = new ListaDoblemeneteEnlazada<string>();

    [Button("A�ade a tu lista")]
    public void AddList(string name)
    {
        listadoble.A�ade(name);
        print("A�ade " + name + " a la lista");
    }
    [Button("Elimina una cancion")]
    public void EliminarCancion(string nombreCancion)
    {
        listadoble.Remove(nombreCancion);
        print(nombreCancion + " fue quitada de tu playlist");
    }
    [Button(" ver todas tus musicas")]
    public void VerMisMusicas()
    {
        listadoble.ReadAll();
    }
    [Button("Mostrar Anterior o Siguiente")]
    public void ReproduceAntesdespues(string nombreActual, string opcion)
    {
        Node<string> actual = listadoble.Seek(nombreActual);
        if (actual != null)
        {
            if (opcion.ToLower() == "anterior")
            {
                if (actual.Prev != null)
                {
                    print("Canci�n anterior: " + actual.Prev.Value);
                }
                else
                {
                    print("No hay canci�n anterior.");
                }
            }
            else if (opcion.ToLower() == "siguiente")
            {
                if (actual.Next != null)
                {
                    print("Canci�n siguiente: " + actual.Next.Value);
                }
                else
                {
                    print("No hay canci�n siguiente.");
                }
            }
            else
            {
                print("Opci�n no v�lida. Escribe 'anterior' o 'siguiente'.");
            }
        }
        else
        {
            print("La canci�n actual no fue encontrada en la lista.");
        }
    }
    [Button("pon una musica")]
    public void reproducirMusica(string elige)
    {
        listadoble.Seek(elige);
        print("Se esta reproduciendo la musica "+ elige);
    }
}