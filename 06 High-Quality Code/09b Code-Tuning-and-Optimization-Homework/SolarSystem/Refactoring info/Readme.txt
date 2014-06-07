
Problem found in class "OrbitsCalculator", method "EarthRotation()"

Original code:
        private void EarthRotation()
        {
			for (decimal step = 0; step <= 360; step+=0.00005m)
			{
				EarthRotationAngle = ((double)step) * Days / EarthRotationPeriod;
			}
            Update("EarthRotationAngle");
        }

replased with:
        private void EarthRotation()
        {
            EarthRotationAngle = 360 * Days / EarthRotationPeriod;
            Update("EarthRotationAngle");
        }
