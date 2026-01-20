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
		var err = GetTree().ChangeSceneToFile("res://Scenes/Level.tscn");
	}

	private void OnPausePressed()
	{
		GD.Print("PAUSE CLICKED");
		var err = GetTree().ChangeSceneToFile("res://Scenes/MainMenu.tscn");
	}

	private void OnQuitPressed()
	{
		GD.Print("QUIT CLICKED");
		GetTree().Quit();
	}
}
