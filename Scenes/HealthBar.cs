using Godot;

public partial class HealthBar : ProgressBar
{
	public override void _Ready()
	{
		// Get the player (adjust path if needed)
		var player = GetNode<Player>("../../Player");

		// Set initial values
		MaxValue = player.MaxHealth;
		Value = player.CurrentHealth;

		// Connect signal safely in C#
		player.HealthChanged += OnHealthChanged;
	}

	private void OnHealthChanged(int current, int max)
	{
		MaxValue = max;
		Value = current;
	}
}
