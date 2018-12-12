import { Chance } from "chance";

export async function calculateCorrelation(testdata: any): Promise<number> {
  const chance: Chance.Chance = new Chance();

  // simulate latency
  await new Promise(resolve =>
    setTimeout(resolve, chance.integer({ min: 300, max: 1500 }))
  );

  console.log(chance.bool());
  // simulate 500's
  if (chance.bool()) {
    throw new Error("Something unexpected happened...");
  } else {
    return chance.floating({ min: 0.1, max: 0.6 });
  }
}
