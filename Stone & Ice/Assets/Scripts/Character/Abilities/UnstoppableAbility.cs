public class UnstoppableAbility : CharacterAbility {
    public CharacterCollision collision;

    public override void Activate() {
        collision.dieOnObstacleCollision = false;
    }

    public override void Deactivate() {
        collision.dieOnObstacleCollision = true;
    }
}
