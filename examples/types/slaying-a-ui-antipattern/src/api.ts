import { Chance } from "chance";

export async function calculateCorrelation(): Promise<number> {
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

export async function withRemoteHandling<T>(
  apiCall: () => Promise<T>
): Promise<RemoteData<T>> {
  try {
    return { state: "success", data: await apiCall() };
  } catch (error) {
    return { state: "error", message: error.message };
  }
}

export type RemoteData<T> =
  | { state: "not-loaded" }
  | { state: "loading" }
  | { state: "success"; data: T }
  | { state: "error"; message: string };
