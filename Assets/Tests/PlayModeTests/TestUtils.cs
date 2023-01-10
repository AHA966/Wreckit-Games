using UnityEngine;
using UnityEngine.UI;

public class TestUtils
{
    /**
     * <summary> Finds a gameobject with a certain name in the children of a parent GameObject </summary>
     * <param name="parent"> The GameObject that will be search for children with a given name </param>
     * <param name="name"> The name of the child GameObject to be searched for </param>
     * <returns> The child of the parent GameObject with a given name </returns>
     * <remarks> Can return null if the given parent is null or if a child does not exist in the parents hierarchy </remarks>
     */
    public static GameObject FindChild(GameObject parent, string name)
    {
        if (parent == null) 
            return null;

        Transform child = parent.transform.Find(name);
        if(child != null)
        {
            return child.gameObject;
        }

        return null;
    }

}
