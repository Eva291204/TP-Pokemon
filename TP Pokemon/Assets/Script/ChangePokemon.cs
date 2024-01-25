using UnityEngine;

public class ChangePokemon : MonoBehaviour
{
    private FightManager fightManager;

    // Start is called before the first frame update
    void Start()
    {
        fightManager = FindObjectOfType<FightManager>();
    }

    public void PokemonSwitch()
    {
        if (fightManager._sachaActifPokemon.IsDead)
        {
            fightManager.SachaSwitchPokemon();
        }
        else if (fightManager._ondineActifPokemon.IsDead)
        {
            fightManager.OndineSwitchPokemon();
        }
    }
}
