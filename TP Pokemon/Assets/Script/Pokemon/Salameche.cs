using UnityEngine;

public class Salameche : Pokemon
{
    public Salameche() : base("Salam�che", 100, 100, 60, 40, 60, "Feu") { } //d�termination des stats du pokemon

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
            int _damage = Atk;

            switch (_pokemonEnnemy.PokemonType)
            {
                //50% de l'attaque --> r�sistance
                case "Feu":
                    _damage = (int)(Atk * 0.5f);   
                    break;
                case "Eau":
                    _damage = (int)(Atk * 0.5f);   
                    break;
                case "Roche":
                    _damage = (int)(Atk * 0.5f);   
                    break;
                case "Dragon":
                    _damage = (int)(Atk * 0.5f);   
                    break;

                //200% de l'attaque --> faiblesse
                case "Plante":
                    _damage = (int)(Atk * 2f);   
                    break;
                case "Glace":
                    _damage = (int)(Atk * 2f);   
                    break;
                case "Insecte":
                    _damage = (int)(Atk * 2f);   
                    break;
                case "Acier":
                    _damage = (int)(Atk * 2f);   
                    break;
                
                default:
                    _damage = Atk;
                    break;
            }

            Debug.Log($"{Name} utilise Flamm�che");
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
