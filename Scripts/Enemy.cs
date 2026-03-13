using System.Linq;
using Godot;

namespace UIProject.Scripts;

public partial class Enemy : Creature
{
	[Signal]
	public delegate void EnemyDiedEventHandler(int points);

	[Export]
	public int Points = 10;

	private bool IsAttacking => _sprite.Animation.ToString() == "attack";
	private bool HasTarget => _hurtBox.GetOverlappingBodies().Any(x => x is Player);

	private Player _player;
	private NavigationAgent2D _navAgent;
	private AnimatedSprite2D _sprite;
	private Area2D _hurtBox;
	private Timer _attackTimer;

	public override void _Ready()
	{
		base._Ready(); // initializes CurrentHealth and HealthBar

		_player = GetTree().CurrentScene.GetNode<Player>("Player");
		if (_player == null)
			GD.PrintErr("Player not found");

		_navAgent = GetNode<NavigationAgent2D>("NavigationAgent2D");
		_sprite = GetNode<AnimatedSprite2D>("Sprite");
		_hurtBox = GetNode<Area2D>("HurtBox");
		_attackTimer = GetNode<Timer>("AttackTimer");

		// Optional: update health bar at start
		UpdateHealthBar();
	}

	public override void _Process(double delta)
	{
		if (_player == null)
			return;

		_navAgent.TargetPosition = _player.GlobalPosition;
		var nextPosition = _navAgent.GetNextPathPosition();

		Velocity = GlobalPosition.DirectionTo(nextPosition).Normalized() * Speed;

		if (!IsAttacking)
			UpdateDirection(Velocity);

		UpdateSpriteAnimation(Velocity, HasTarget);

		if (IsAttacking)
			Velocity = Vector2.Zero;

		MoveAndSlide();
	}

	public void TakeDamage(int damage)
	{
		GD.Print("enemy hit");

		// Reduce health
		CurrentHealth -= damage;

		// Update health bar
		UpdateHealthBar();

		// Die if health is 0
		if (CurrentHealth <= 0)
		{
			GD.Print("Enemy died");
			EmitSignal(SignalName.EnemyDied, Points);
			QueueFree();
		}
	}

	private void UpdateDirection(Vector2 direction)
	{
		if (direction.X < 0)
		{
			_sprite.FlipH = true;
			if (_hurtBox.Position.X > 0)
				_hurtBox.Position = new Vector2(-_hurtBox.Position.X, _hurtBox.Position.Y);
		}
		else if (direction.X > 0)
		{
			_sprite.FlipH = false;
			if (_hurtBox.Position.X < 0)
				_hurtBox.Position = new Vector2(-_hurtBox.Position.X, _hurtBox.Position.Y);
		}
	}

	private void UpdateSpriteAnimation(Vector2 direction, bool attacking)
	{
		if (!IsAttacking)
		{
			_sprite.Play(direction != Vector2.Zero ? "walk" : "idle");

			if (attacking)
			{
				_sprite.Play("attack");
				Velocity = Vector2.Zero;
				_sprite.Pause();
				_attackTimer.Start();
			}
		}
	}

	private void ResumeAttack()
	{
		_sprite.Play("attack");
	}

	private void DealDamage()
	{
		if (_sprite.Animation.ToString() == "attack")
		{
			var bodies = _hurtBox.GetOverlappingBodies();
			foreach (var body in bodies)
			{
				if (body is Player player)
					player.TakeDamage(1);
			}
			_sprite.Play("idle");
		}
	}
}
