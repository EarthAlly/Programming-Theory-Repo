using Animals.Base;

namespace Animals
{
    // INHERITANCE
    public class Dog : Animal
    {
        // POLYMORPHISM
        protected override void PlaySoundEffect()
        {
            base.PlaySoundEffect();
            Talk("I'm making a doggy sound!", 1);
        }
    }
}
