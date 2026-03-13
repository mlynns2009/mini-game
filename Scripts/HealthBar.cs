using Godot;

public partial class HealthBar : ProgressBar
{
	public void UpdateHealth(int currentHealth, int maxHealth)
	{
		GD.Print("health bar should update");
		MaxValue = maxHealth;
		Value = currentHealth;
	}
}
