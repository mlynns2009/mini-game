using Godot;



public partial class Creature : CharacterBody2D
{
	[Signal]
	public delegate void HealthChangedEventHandler(int currentHealth, int maxHealth);

	[Export]
	public int MaxHealth = 3;
	[Export]
	public float Speed = 300.0f;
	
	public int CurrentHealth;
	public void EmitHealthChanged()
	{
		EmitSignal(SignalName.HealthChanged, CurrentHealth, MaxHealth);
	}
 
}

  
  
