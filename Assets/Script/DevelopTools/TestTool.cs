
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using Unity;
using UnityEngine.UIElements;

public class TestTool : EditorWindow
{
    
    [MenuItem("Window/Comvine_Develop_Tools")]
    public static void ShowWindow()
    {
        EditorWindow wnd = GetWindow<TestTool>();
        wnd.titleContent = new GUIContent("TestTools");
       
    }

    private void OnEnable()
    {

        var allObjectGuids = AssetDatabase.FindAssets("t:Sprite");
        var allObjects = new List<Sprite>();
        foreach(var guid in allObjectGuids)
        {
            allObjects.Add(AssetDatabase.LoadAssetAtPath<Sprite>(AssetDatabase.GUIDToAssetPath(guid)));
        }
        // Create a two-pane view with the left pane being fixed with
        var splitView = new VisualElement();
        
        // Add the view to the visual tree by adding it as a child to the root element
        rootVisualElement.Add(splitView);

        // A TwoPaneSplitView always needs exactly two child elements
        var leftPane = new VisualElement();
        splitView.Add(leftPane);
        var rightPane = new VisualElement();
        splitView.Add(rightPane);
        //leftPane.makeItem = () => new Label();
        //leftPane.bindItem = (item, index) => { (item as Label).text = allObjects[index].name; };
        //leftPane.itemsSource = allObjects;
    }

    private void OnGUI()
    {

    }
}
