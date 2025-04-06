using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.UI;

public class gameManagerr : MonoBehaviour
{
    ListaDoblemeneteEnlazada<string> listadoble = new ListaDoblemeneteEnlazada<string>();

    [Button("Añade a tu lista")]
    public void AddList(string name)
    {
        listadoble.Añade(name);
        print("Añade " + name + " a la lista");
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
                    print("Canción anterior: " + actual.Prev.Value);
                }
                else
                {
                    print("No hay canción anterior.");
                }
            }
            else if (opcion.ToLower() == "siguiente")
            {
                if (actual.Next != null)
                {
                    print("Canción siguiente: " + actual.Next.Value);
                }
                else
                {
                    print("No hay canción siguiente.");
                }
            }
            else
            {
                print("Opción no válida. Escribe 'anterior' o 'siguiente'.");
            }
        }
        else
        {
            print("La canción actual no fue encontrada en la lista.");
        }
    }
    [Button("pon una musica")]
    public void reproducirMusica(string elige)
    {
        listadoble.Seek(elige);
        print("Se esta reproduciendo la musica "+ elige);
    }
}