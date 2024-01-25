using UnityEngine;

public class Carapuce : Pokemon
{
    public Carapuce() : base("Carapuce", 100, 100, 50, 60, 50, "Eau") { } //d�termination des stats du pokemon

    public override void Attack(Pokemon _pokemonEnnemy)
    {
        if (!IsDead)
        {
            int _damage = (int)(Atk * 0.2f);                   //20% de l'attaque

            switch (_pokemonEnnemy.PokemonType)
            {
                //50% de l'attaque --> r�sistance
                case "Roche":
                    _damage = (int)(Atk * 0.1f);
                    break;
                case "Acier":
                    _damage = (int)(Atk * 0.1f);
                    break;
                case "Spectre":
                    _damage = 0;
                    break;
            }

            Debug.Log($"{Name} utilise Charge");
            Debug.Log($"{_pokemonEnnemy.Name} re�oit {_damage} d�g�ts");
            _pokemonEnnemy.TakeDamage(_damage);
        }
    }
    public override void AttackSpe(Pokemon _pokemonEnnemy)
    {
        if (!IsDead)
        {
            int _damage = (int)(Atk * 0.9f);          //90% de l'attaque

            switch (_pokemonEnnemy.PokemonType)
            {
                //50% de l'attaque --> r�sistance
                case "Eau":
                    _damage = (int)(Atk * 0.45f);
                    break;
                case "Plante":
                    _damage = (int)(Atk * 0.45f);
                    break;
                case "Dragon":
                    _damage = (int)(Atk * 0.45f);
                    break;

                //200% de l'attaque --> faiblesse
                case "Feu":
                    _damage = (int)(Atk * 1.8f);
                    break;
                case "Sol":
                    _damage = (int)(Atk * 1.8f);
                    break;
                case "Roche":
                    _damage = (int)(Atk * 1.8f);
                    break;

                default:
                    _damage = Atk;
                    break;
            }

            Debug.Log($"{Name} utilise Pistolet � O");
            Debug.Log($"{_pokemonEnnemy.Name} re�oit {_damage} d�g�ts");
            _pokemonEnnemy.TakeDamage(_damage);
        }
    }

    public override void TakeDamage(int _damage)
    {
        PV = PV - _damage;

        if (PV <= 0)
        {
            Debug.Log($"{Name} PV : 0");
            Die();
        }
        else
        {
            Debug.Log($"{Name} PV : {PV}");
        }
    }
    public override void Die()
    {
        IsDead = true;
        ChangePokemon changepokemon = FindObjectOfType<ChangePokemon>();
        Debug.Log($"{Name} est K.O");
        changepokemon.PokemonSwitch();
    }
}
