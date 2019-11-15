using UnityEngine;
using System.Collections;

public class ShowGameMenu : MonoBehaviour
{
	
	public string m_menuSceneName;
	public enum TPushSceneType { PUSH_SCENE, POP_SCENE};
	public TPushSceneType m_type = TPushSceneType.PUSH_SCENE;
	public bool m_clearReturnScene = false;
	
	protected void Awake()
	{
        //TODO 1: nos registras en el input al boton return con OnReturnPressed.

        //SceneMgr sceneMgr = GameMgr.GetInstance().GetServer<SceneMgr>();
        InputMgr inputMng = GameMgr.GetInstance().GetServer<InputMgr>();
        inputMng.RegisterReturn(OnReturnPressed);
    }
	
	protected void OnReturnPressed()
    {
        SceneMgr sceneMgr = GameMgr.GetInstance().GetServer<SceneMgr>();
        //muestro el menu..
        //TODO 2 if type == TPushSceneType.PUSH_SCENE => PushScene else ReturnScene
        if (m_type == TPushSceneType.PUSH_SCENE) { 
            //Debug.LogError("apilamos la escena de menu ");
            sceneMgr.PushScene(m_menuSceneName);
        }
        else {
            //Debug.LogError("Desapilamos la escena en la cima de la pila");
            sceneMgr.PopScene(m_clearReturnScene);
        }
    }

    protected void OnDestroy() 
	{
        //TODO 3 desregistrar el return.
        InputMgr input = GameMgr.GetInstance().GetServer<InputMgr>();
        if (input != null)
            input.UnRegisterReturn(OnReturnPressed);

    }

    /*protected virtual void Tick(float deltaTime){}
	protected virtual void Init(){}
	
	protected virtual void End() {}*/
}
