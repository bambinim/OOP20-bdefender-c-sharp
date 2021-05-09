using OOP20bdefender.DavideBaldelli.tower.interactor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP20bdefender.DavideBaldelli.tower
{

    delegate void DamageApplier(int id, ITower tower);

    class TowerFactory
    {

        private static double NEXT_LEVEL_MULT = 0.25;

        public static ITower GetDirectShootTower(TowerData towerData, DirectTowerEnemiesInteractor interactor, Pair<Double, Double> pos)
        {
            return new CustomTower(towerData, interactor, pos, new SelectCloserEnemy(), (id, tower) => interactor.applyDamageById(id, towerData.damage + ((tower.getLevel() - 1) * NEXT_LEVEL_MULT)));
        }


        private class CustomTower : ITower
        {
            private TowerData data;
            private EnemiesInteractor interactor;
            private Pair<Double, Double> pos;
            private TargetSelectionAlgorithm selectionAlgorithm;
            private DamageApplier damageApplier;
            private int level = 1;
            public CustomTower(TowerData towerData, EnemiesInteractor interactor, Pair<Double, Double> pos, TargetSelectionAlgorithm selectionAlgorithm, DamageApplier damageApplier)
            {
                this.data = towerData;
                this.interactor = interactor;
                this.pos = pos;
                this.selectionAlgorithm = selectionAlgorithm;
                this.damageApplier = damageApplier;
            }
            public int getLevel()
            {
                return this.level;
            }

            public Pair<double, double> getPosition()
            {
                return this.pos;
            }

            public long getShootSpeed()
            {
                return data.shootSpeed;
            }

            public int getTowerTypeId()
            {
                return this.data.id;
            }

            public Pair<double, double> shoot()
            {
                try
                {
                    int targetId = this.getOptimalTarget();
                    Console.WriteLine("Shooting at enemy [" + targetId + "]");
                    damageApplier(targetId, this);
                    return this.interactor.getEnemyPosById(targetId);
                }
                catch (NoEnemiesAroundException ex)
                {
                    return null;
                }
            }

            public int upgradeLevel()
            {
                return ++this.level;
            }

            private int getOptimalTarget()
            {
                return this.selectionAlgorithm.getBestTargetId(this.interactor, this.data.rangeRadius + this.level - 1, this.pos);
            }

        }
    }
}
