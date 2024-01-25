using UnityEngine;

public class Bulbizarre : Pokemon
{
    public Bulbizarre() : base("Bulbizarre", 120, 120, 40, 60, 30, "Plante") { } //détermination des stats du pokemon

    public override void Attack(Pokemon _pokemonEnnemy)
    {
        if (!IsDead)
        {
            int _damage = (int)(Atk * 0.2f);                   //20% de l'attaque

            switch (_pokemonEnnemy.PokemonType)
            {
                //50% de l'attaque --> résistance
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
            Debug.Log($"{_pokemonEnnemy.Name} reçoit {_damage} dégâts");
            _pokemonEnnemy.TakeDamage(_damage);
        }
    }
    public override void AttackSpe(Pokemon _pokemonEnnemy)
    {
        if (!IsDead)
        {
            PV = PV + 30;

            if (PV > MaxPV)
            {
                PV = MaxPV;
            }

            Debug.Log($"{Name} utilise Soin");
            Debug.Log($"{Name} PV : {PV}");
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
