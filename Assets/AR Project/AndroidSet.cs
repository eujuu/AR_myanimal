using UnityEngine;

public class AndroidSet : MonoBehaviour
{
    /*
    /#if UNITY_ANDROID

        static public AndroidToast instance;

        AndroidJavaObject currentActivity;
        AndroidJavaClass UnityPlayer;
        AndroidJavaObject context;
        AndroidJavaObject toast;


        void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);

            UnityPlayer =  new AndroidJavaClass("com.unity3d.player.UnityPlayer");

            currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");


            context = currentActivity.Call<AndroidJavaObject>("getApplicationContext");

            DontDestroyOnLoad(this.gameObject);
        }
        void ShowToast(string message)
        {
            currentActivity.Call
            (
                "runOnUiThread", 
                new AndroidJavaRunnable(() =>
                {
                    AndroidJavaClass Toast = new AndroidJavaClass("android.widget.Toast");

                    AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", message);

                    toast = Toast.CallStatic<AndroidJavaObject>
                    (
                        "makeText", 
                        context, 
                        javaString, 
                        Toast.GetStatic<int>("LENGTH_SHORT")
                    );

                    toast.Call("show");
                })
             );
        }
        public void CancelToast()
        {
            currentActivity.Call("runOnUiThread", 
                new AndroidJavaRunnable(() =>
                {
                    if (toast != null) toast.Call("cancel");
                }));
        }


    #else
        void Awake()
        {
            Destroy(gameObject);
        }
    #endif
    */




    private AndroidJavaObject curActivity = null;
    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            curActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        }
    }
    private void OnGUI()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if ( GUI.Button(new Rect(200, 100, 300, 200), "토스트 보여줘"))
            {
                curActivity.Call("runonUiThread", new AndroidJavaRunnable(() =>
                //안드로이드에 있는 유니티플레이어 클래스에 접근하고 해당 클래스를 통해 현재 유니티가 동작하는 액티비틸ㄹ 가져오도록 한다.
                //이 액티비티를 통해서 해당 기능을 호출해야 하기 때문에 보관해 둔다.
                {
                    AndroidJavaObject toast = new AndroidJavaObject("android.widget.Toast", curActivity);
                    toast.CallStatic<AndroidJavaObject>("makeText", curActivity, "토스트당", 0).Call("show");

                }));
            }
            if (GUI.Button(new Rect(200, 400, 300, 100), "종료"))
                Application.Quit();
        }
    }
}
