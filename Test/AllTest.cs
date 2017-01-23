using UnityEngine;
using UnityEngine.UI;

public class AllTest : MonoBehaviour
{
    public Button MuteBtn;
    public Transform GoParent;

    private string One = "Ballade pour Adelin";
    private string Two = "Flower Dance";
    private string Three = "Melody Of The Night 5";
    private string Four = "The Dawn";
    private bool IsMute = false;

    private string Bullet = "Bullet";
    private string Effect = "Effect";

    public void OnOneBtnClick()
    {
        AudioManager.Instance.Play(One);
    }

    public void OnTwoBtnClick()
    {
        AudioManager.Instance.Play(Two);
    }

    public void OnThreeBtnClick()
    {
        AudioManager.Instance.Play(Three);
    }

    public void OnFourBtnClick()
    {
        AudioManager.Instance.Play(Four);
    }

    public void OnMuteBtnClick()
    {
        if (IsMute)
        {
            IsMute = false;
            AudioManager.Instance.SetMute(false);
            MuteBtn.GetComponentInChildren<Text>().text = "开启音效";
        }
        else
        {
            IsMute = true;
            AudioManager.Instance.SetMute(true);
            MuteBtn.GetComponentInChildren<Text>().text = "关闭音效";
        }
    }

    public void OnBulletBtnClick()
    {
        GameObject go = PoolManager.Instance.GetInstance(Bullet);
        go.transform.SetParent(GoParent);
        // TODO
    }

    public void OnEffectBtnClick()
    {
        GameObject go = PoolManager.Instance.GetInstance(Effect);
        go.transform.SetParent(GoParent);
        // TODO
    }
}
