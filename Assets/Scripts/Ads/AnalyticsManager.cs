using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using UnityEngine;

namespace Ads
{
    public class AnalyticsManager : MonoBehaviour
    {
        public static AnalyticsManager Instance { get; private set; }
        async  void Start()
        {
            try
            {
                await UnityServices.InitializeAsync();
                List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
                
            }
            catch (ConsentCheckException e)
            {
                //Something went wrong when checking the GeoIP, check the e.Reason and handle appropriately.
            }
        }

        public void OnNewGameStart()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
               
            };
            AnalyticsService.Instance.CustomData("NewGameStart", parameters);
            AnalyticsService.Instance.Flush();
            Debug.Log("AnalyticNewGameStart");
        }

        public void OnGameFail()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                

            };
            AnalyticsService.Instance.CustomData("GameFail", parameters);
            AnalyticsService.Instance.Flush();
                
            Debug.Log("AnalyticGameFail");
        }
    }
}
