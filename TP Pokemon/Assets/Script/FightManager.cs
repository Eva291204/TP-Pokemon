using UnityEngine;

public class FightManager : MonoBehaviour
{
    public int Seed;

    public Pokemon _sachaActifPokemon;
    public Pokemon _ondineActifPokemon;

    private Pokemon[] PokemonSacha = { new Salameche(), new Bulbizarre(), new Carapuce(), new Pikachu() };
    private Pokemon[] PokemonOndine = { new Salameche(), new Bulbizarre(), new Carapuce(), new Pikachu() };

    public Pokemon[] SachaPokemons { get { return PokemonSacha; } }
    public Pokemon[] OndinePokemons { get { return PokemonOndine; } }

    private int pokemonSachaPlaceInBackpack;
    private int pokemonOndinePlaceInBackpack;

    private void Start()
    {
        Seed = Random.Range(0, 1000); //détermination du terrain
        Random.InitState(Seed);
        Debug.Log("Terrain :" + Seed);

        for (int i = 0; i < 2; i++)
        {
            int _sachaRandomPokemon = Random.Range(0, PokemonSacha.Length);
            int _ondineRandomPokemon = Random.Range(0, PokemonOndine.Length);    //définition des 2 pokemons pour Sacha et Ondine
            PokemonSacha[i] = PokemonSacha[_sachaRandomPokemon];
            PokemonOndine[i] = PokemonOndine[_ondineRandomPokemon];
        }

        Debug.Log($"Sacha possède {PokemonSacha[0].Name} et {PokemonSacha[1].Name} ");
        Debug.Log($"Ondine possède {PokemonOndine[0].Name} et {PokemonOndine[1].Name}");

        _sachaActifPokemon = PokemonSacha[0];        //le 1er pokemon du tableau devient le pokemon actif du dresseur, celui en dehors de la pokeball
        _ondineActifPokemon = PokemonOndine[0];

        Debug.Log($"Sacha : {_sachaActifPokemon.Name} je te choisiis !");
        Debug.Log($"Ondine : {_ondineActifPokemon.Name} je te choisis !");
    }

    public void SachaTeamAttack() //pour l'UI
    {
        _sachaActifPokemon.Attack(_ondineActifPokemon);
    }
    public void OndineTeamAttack() //pour l'UI
    {
        _ondineActifPokemon.Attack(_sachaActifPokemon);
    }
    public void SashaTeamAttackSpe() //pour l'UI
    {
        _sachaActifPokemon.AttackSpe(_ondineActifPokemon);
    }
    public void OndineTeamAttackSpe() //pour l'UI
    {
        _ondineActifPokemon.AttackSpe(_sachaActifPokemon);
    }

    public void SachaSwitchPokemon()
    {
        Debug.Log($"Sacha change de Pokemon");
        pokemonSachaPlaceInBackpack++;

        if (PokemonSacha[1].IsDead == false && pokemonSachaPlaceInBackpack <= 1)
        {
            _sachaActifPokemon = PokemonSacha[1];
            Debug.Log($"Sacha : {_sachaActifPokemon.Name} je te choisis !");
        }
        else if (PokemonSacha[0].IsDead == false && pokemonSachaPlaceInBackpack > 1)
        {
            pokemonSachaPlaceInBackpack = 0;
            _sachaActifPokemon = PokemonSacha[0];
            Debug.Log($"Sacha : {_sachaActifPokemon.Name} je te choisis !");
        }
        else
        {
            MatchEnd();
        }
    }

    public void OndineSwitchPokemon()
    {
        Debug.Log($"Ondine change de Pokemon");
        pokemonOndinePlaceInBackpack++;

        if (PokemonOndine[1].IsDead == false && pokemonOndinePlaceInBackpack <= 1)
        {
            _ondineActifPokemon = PokemonOndine[1];
            Debug.Log($"Ondine : {_ondineActifPokemon.Name} je te choisis !");
        }
        else if (PokemonOndine[0].IsDead == false && pokemonOndinePlaceInBackpack > 1)
        {
            pokemonOndinePlaceInBackpack = 0;
            _ondineActifPokemon = PokemonOndine[0];
            Debug.Log($"Ondine : {_ondineActifPokemon.Name} je te choisis !");
        }
        else
        {
            MatchEnd();
        }


        //renvoie null..

        //for (int i = 0; i <= PokemonOndine.Length; i++)
        //{
        //    if (PokemonOndine[i].IsDead == false && PokemonOndine[i].Name != _ondineActifPokemon.Name)
        //    {
        //        PokemonOndine[i] = _ondineActifPokemon;
        //    }
        //}
        //Debug.Log($"Ondine : {_ondineActifPokemon.Name} je te choisis !");
    }

    public void MatchEnd()
    {
        Debug.Log("Fin du combat");

        if (PokemonSacha[0].IsDead && PokemonSacha[1].IsDead)
        {
            Debug.Log("Ondine a gagné");
        }
        else
        {
            Debug.Log("Sacha a gagné");
        }
    }
}
