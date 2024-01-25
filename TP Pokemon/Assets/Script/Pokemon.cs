using UnityEngine;

public abstract class Pokemon : MonoBehaviour
{
    public PokemonDamage PokemonDamage;

    public string Name;
    public int PV;
    public int MaxPV;
    public int Atk;
    public int Def;
    public int Speed;

    public bool InPokeball;
    public bool IsDead;

    public string PokemonType;

    public Pokemon(string _name, int _PV, int _maxPV, int _atk, int _def, int _speed, string _pokemonType)
    {
        this.Name = _name;
        PV = _PV;
        MaxPV = _maxPV;
        Atk = _atk;
        Def = _def;
        Speed = _speed;
        PokemonType = _pokemonType;
    }

    public abstract void Attack(Pokemon _pokemonEnnemy);
    public abstract void AttackSpe(Pokemon _pokemonEnnemy);
    public abstract void TakeDamage(int _dammage);
    public abstract void Die();

}
