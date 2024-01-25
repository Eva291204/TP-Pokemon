using UnityEngine;

public class Healer : MonoBehaviour
{
    private FightManager fightManager;
    private Pokemon[] sachaPokemons;
    private Pokemon[] ondinePokemons;

    public int heal = 20;
    private void Start()
    {
        fightManager = FindObjectOfType<FightManager>();
        sachaPokemons = fightManager.SachaPokemons;
        ondinePokemons = fightManager.OndinePokemons;
    }

    public void SoinTeamSacha()
    {
        if (fightManager._sachaActifPokemon.IsDead == false)
        {
            fightManager._sachaActifPokemon.PV = fightManager._sachaActifPokemon.MaxPV;
            Debug.Log($"Pierre soigne entièrement {fightManager._sachaActifPokemon.Name} de Sacha");
        }
    }

    public void SoinTeamOndine()
    {
        if (fightManager._ondineActifPokemon.IsDead == false)
        {
            fightManager._ondineActifPokemon.PV = fightManager._ondineActifPokemon.MaxPV;
            Debug.Log($"Pierre soigne entièrement {fightManager._ondineActifPokemon.Name} d'Ondine");
        }
    }

    public void Cuisiner()
    {
        Debug.Log($"Pierre cuisine pour soigner tous les Pokemons");

        for (int i = 0; i < sachaPokemons.Length; i++)
        {
            if (sachaPokemons[i].PV < sachaPokemons[i].MaxPV - heal && sachaPokemons[i].IsDead == false) //vérifie que le pokemon est vivant et que ses pv sont inférieurs
            {
                sachaPokemons[i].PV += heal;
            }
            else
            {
                sachaPokemons[i].PV = sachaPokemons[i].MaxPV;
            }
            Debug.Log($"Sacha : {sachaPokemons[i].Name} : PV = {sachaPokemons[i].PV}");
        }

        for (int i = 0; i < ondinePokemons.Length; i++)
        {
            if (ondinePokemons[i].PV < ondinePokemons[i].MaxPV - heal && ondinePokemons[i].IsDead == false)
            {
                ondinePokemons[i].PV += heal;
            }
            else
            {
                ondinePokemons[i].PV = ondinePokemons[i].MaxPV;
            }
            Debug.Log($"Ondine : {ondinePokemons[i].Name} : PV = {ondinePokemons[i].PV}");
        }
    }
}