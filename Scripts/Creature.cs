using Godot;

namespace UIProject.Scripts;

public partial class Creature : CharacterBody2D
{
	[Signal]
	public delegate void HealthChangedEventHandler(int currentHealth, int maxHealth);

	[Export]
	public int MaxHealth = 3;
	[Export]
	public float Speed = 300.0f;

	protected int CurrentHealth;
	protected HealthBar healthBar;

	public override void _Ready()
	{
		CurrentHealth = MaxHealth;

		// Assign HealthBar if it exists
		if (GetNodeOrNull<HealthBar>("HealthBar") != null)
		{
			healthBar = GetNode<HealthBar>("HealthBar");
			healthBar.UpdateHealth(CurrentHealth, MaxHealth);
		}
	}

	// Call this whenever health changes
	protected void UpdateHealthBar()
	{
		EmitSignal(SignalName.HealthChanged, CurrentHealth, MaxHealth);
		if (healthBar != null)
			healthBar.UpdateHealth(CurrentHealth, MaxHealth);
	}
}
