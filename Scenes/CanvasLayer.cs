using Godot;

public partial class UIManager : CanvasLayer
{
	private ProgressBar _healthBar;

	public override void _Ready()
	{
		_healthBar = GetNode<ProgressBar>("HealthBar");

		var player = GetNode<Player>("../Player"); 
		player.HealthChanged += OnPlayerHealthChanged;

		// initialize values
		_healthBar.MaxValue = player.MaxHealth;
		_healthBar.Value = player.CurrentHealth;
	}

	private void OnPlayerHealthChanged(int current, int max)
	{
		_healthBar.MaxValue = max;
		_healthBar.Value = current;
	}
}
