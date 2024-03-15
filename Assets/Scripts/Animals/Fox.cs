using Animals.Base;

namespace Animals
{
    // INHERITANCE
    public class Fox : Animal
    {
        // POLYMORPHISM
        protected override void PlaySoundEffect()
        {
            base.PlaySoundEffect();
            Talk("I'm making a foxy sound!", 1);
        }
    }
}
