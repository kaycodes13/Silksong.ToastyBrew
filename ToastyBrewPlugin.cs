using BepInEx;
using HarmonyLib;

namespace ToastyBrew;

[BepInAutoPlugin(id: "io.github.kaycodes13.toastybrew")]
public partial class ToastyBrewPlugin : BaseUnityPlugin {
	private static Harmony Harmony { get; } = new(Id);
	private void Awake() {
		Logger.LogInfo($"Plugin {Name} ({Id}) has loaded!");
		Harmony.PatchAll(typeof(ToastyBrewPlugin));
	}

	[HarmonyPatch(typeof(HeroController), nameof(HeroController.GetTotalFrostSpeed))]
	[HarmonyPostfix]
	private static void ColdResistance(HeroController __instance, ref float __result) {
		if (__instance.quickeningTimeLeft > 0)
			__result *= 0.7f;
	}
}
