using System;
using System.Collections.Generic;
using Game.Analytics;
using Game.ScreenManager;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Game.UI
{
    public class AnalyticsViewModel
    {
        [Inject] private IScreenManager _screenManager;
        [Inject] private IAnalytics _analytics;

        public void PopulateList(ListView reportList)
        {
            var datas = _analytics.GetData();
            var items = new List<string>(datas.Count); 
            
            for (int i = 0; i < datas.Count; i++)
                items.Add($"{datas[i].Key} : {datas[i].Value} : {datas[i].Date}");
            
            Func<VisualElement> makeItem = () => new Label(); 

            Action<VisualElement, int> bindItem = (e, i) => (e as Label).text = items[i]; 

            reportList.makeItem = makeItem; 
            reportList.bindItem = bindItem; 
            reportList.itemsSource = items; 
            reportList.selectionType = SelectionType.Multiple; 
            // Callback invoked when the user double clicks an item 
            reportList.itemsChosen += (selectedItems) => { Debug.Log("Items chosen: " + string.Join(", ", selectedItems)); }; 
            // Callback invoked when the user changes the selection inside the ListView 
            reportList.selectionChanged += (selectedItems) => { Debug.Log("Items selected: " + string.Join(", ", selectedItems)); };
        }

        public void CloseScreen()
        {
            _screenManager.Close<AnalyticsView>();
        }
    }
}