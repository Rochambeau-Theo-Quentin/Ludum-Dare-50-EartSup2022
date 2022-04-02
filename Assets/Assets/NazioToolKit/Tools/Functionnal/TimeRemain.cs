namespace NazioToolKit
{
    public class TimeRemain
    {
        private float remainingTime = 0;
        private float percentTime = 0;

        private float maxTime = 1;

        public void SetTime(float _time)
        {
            maxTime = _time;
            remainingTime = maxTime;

            if (maxTime == 0) maxTime = 0.00001f;
        }

        public float GetRemainingTime()
        {
            return remainingTime;
        }

        public float GetPercentTime()
        {
            return percentTime;
        }

        public void RecalculTime(float _minusTime)
        {
            remainingTime -= _minusTime;
            percentTime = remainingTime / maxTime;
        }

        public void NoneTime()
        {
            remainingTime = 0;
            percentTime = 0f;
        }
    }
}