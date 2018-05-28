using UnityEngine;

[System.Serializable]
public class Player {
    public int id;
    public string nickname;
    public int experience;
    public int money;
    public int act_round;
    //Stats
    public int VidaMax;
    public int DmgMele;
    public int Torreta;
    public int Suerte;
    public int DmgRange;

    public Player(int id, string nombre, int experience, int money, int act_round, int VidaMax, int DmgMele, int generacionOnline, int suerte, int DmgRange)
    {
        this.id = id;
        this.nickname = nombre;
        this.experience = experience;
        this.money = money;
        this.act_round = act_round;

        this.VidaMax = VidaMax;
        this.DmgMele = DmgMele;
        this.Torreta = generacionOnline;
        this.Suerte = suerte;
        this.DmgRange = DmgRange;
    }

    public int getVida()
    {
        return (int) (((this.VidaMax / 10)-0.1)+1) * 100;
    }
    public int getdmg()
    {
        return (int) (((this.DmgRange / 10) - 0.1) + 1) * 10;
    }

    public string toJson()
    {
        return JsonUtility.ToJson(this);
    }
}
