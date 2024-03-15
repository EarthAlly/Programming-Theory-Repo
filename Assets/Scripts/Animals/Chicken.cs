using Animals.Base;

namespace Animals
{
    // INHERITANCE
    public class Chicken : Animal
    {
        // POLYMORPHISM
        protected override void PlaySoundEffect()
        {
            base.PlaySoundEffect();
            Talk("I'm making a chicken-ky sound!", 1);
        }
    }
}
