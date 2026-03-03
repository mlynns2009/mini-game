using Godot;

public partial class Player : Creature
{
	[Signal]
	public delegate void LivesChangedEventHandler(int lives);

	[Export] public int Lives = 3;

	private Vector2 _startPosition;
	private AnimatedSprite2D _sprite;
	private Area2D _hurtBox;

	private bool IsAttacking => 
		_sprite.Animation == "attack" && _sprite.IsPlaying();

	public override void _Ready()
	{
		base._Ready();

		_startPosition = GlobalPosition;
		_sprite = GetNode<AnimatedSprite2D>("Sprite");
		_hurtBox = GetNode<Area2D>("HurtBox");

		EmitHealthChanged(); // initialize UI
	}

	public override void _PhysicsProcess(double delta)
	{
		var direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		UpdateVelocity(direction);
		MoveAndSlide();
	}

	public void TakeDamage(int damage)
	{
		CurrentHealth -= damage;

		if (CurrentHealth <= 0)
		{
			Lives--;
			EmitSignal(SignalName.LivesChanged, Lives);

			if (Lives <= 0)
			{
				GD.Print("Game Over");
				GetTree().Quit();
				return;
			}

			GlobalPosition = _startPosition;
			CurrentHealth = MaxHealth;
		}

		EmitHealthChanged();
	}

	private void UpdateVelocity(Vector2 direction)
	{
		if (direction != Vector2.Zero)
			Velocity = direction * 200;
		else
			Velocity = Vector2.Zero;
	}
}
