using NUnit.Framework;
using MinefieldGame.GameControl;
using MinefieldGame.GameModels;

[TestFixture]
public class MinefieldGameTests
{
    [Test]
    public void MovePlayer_HitsMine_LosesLife()
    {
        var minefield = new bool[8, 8];
        minefield[1, 0] = true; // Place a mine at position (1, 0)
        var game = new MinefieldGameLogic(minefield);

        game.MovePlayer(MoveDirection.Down);

        Assert.AreEqual(2, game.Lives);
        Assert.AreEqual(1, game.Moves);
        Assert.AreEqual(1, game.PlayerPosition.X);
        Assert.AreEqual(0, game.PlayerPosition.Y);
    }

    [Test]
    public void MovePlayer_DoesNotHitMine_LifeUnchanged()
    {
        var minefield = new bool[8, 8];
        var game = new MinefieldGameLogic(minefield);

        game.MovePlayer(MoveDirection.Right);

        Assert.AreEqual(3, game.Lives);
        Assert.AreEqual(1, game.Moves);
        Assert.AreEqual(0, game.PlayerPosition.X);
        Assert.AreEqual(1, game.PlayerPosition.Y);
    }

    [Test]
    public void MovePlayer_MultipleMoves_CorrectPosition()
    {
        var minefield = new bool[8, 8];
        var game = new MinefieldGameLogic(minefield);

        game.MovePlayer(MoveDirection.Right);
        game.MovePlayer(MoveDirection.Down);

        Assert.AreEqual(3, game.Lives);
        Assert.AreEqual(2, game.Moves);
        Assert.AreEqual(1, game.PlayerPosition.X);
        Assert.AreEqual(1, game.PlayerPosition.Y);
    }

    [Test]
    public void IsGameWin_PlayerReachesEnd_GameWin()
    {
        var minefield = new bool[8, 8];
        var game = new MinefieldGameLogic(minefield);    
        for (int i = 0; i < 7; i++) game.MovePlayer(MoveDirection.Down);

        Assert.IsTrue(game.IsGameWin());
    }

    [Test]
    public void IsGameOver_PlayerLosesAllLives_GameOver()
    {
        var minefield = new bool[8, 8];
        minefield[1, 0] = true; // Place a mine at position (1, 0)
        var game = new MinefieldGameLogic(minefield);

        game.MovePlayer(MoveDirection.Down);
        game.MovePlayer(MoveDirection.Up);
        game.MovePlayer(MoveDirection.Down);
        game.MovePlayer(MoveDirection.Up);
        game.MovePlayer(MoveDirection.Down);

        Assert.IsTrue(game.IsGameOver());
    }
}
