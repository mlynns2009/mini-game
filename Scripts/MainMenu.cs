using Godot;

public partial class MainMenu : Control
{
	public override void _Ready()
	{
		GD.Print("MAIN MENU READY");

		GetNode<Button>("Panel/VBoxContainer/StartButton").Pressed += OnStartPressed;
		GetNode<Button>("Panel/VBoxContainer/PauseButton").Pressed += OnPausePressed;
		GetNode<Button>("Panel/VBoxContainer/QuitButton").Pressed += OnQuitPressed;
	}

	private void OnStartPressed()
	{
		GD.Print("START CLICKED");
		var err = GetTree().ChangeSceneToFile("res://Scenes/Level.tscn"); // Use exact path!
		GD.Print($"Scene change result: {err}");
	}

	private void OnPausePressed()
	{
		GD.Print("PAUSE CLICKED");
		// Later you can show a Pause menu or freeze the game
	}

	private void OnQuitPressed()
	{
		GD.Print("QUIT CLICKED");
		GetTree().Quit();
	}
}
