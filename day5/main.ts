import { readFileSync } from "node:fs";

interface FreshIngredient {
  lower: number;
  upper: number;
}

function parseFile(filename: string): {
  freshIngredientRange: FreshIngredient[] | undefined;
  ingredientIds: number[] | undefined;
} {
  const data = readFileSync(filename, "utf8");

  const splitData = data.split(/\n\s*\n/);

  const freshIngredientRange: FreshIngredient[] | undefined = splitData[0]
    ?.split("\n")
    .map((range) => {
      const splitRange = range.split("-");
      return {
        lower: Number(splitRange[0]),
        upper: Number(splitRange[1]),
      };
    });
  const ingredientIds = splitData[1]?.split("\n").map((val) => Number(val));

  return { freshIngredientRange, ingredientIds };
}

function partOne(
  freshIngredientRange: FreshIngredient[],
  ingredientIds: number[]
) {
  const checkedIngredients: Number[] = [];
  let fresh = 0;

  ingredientIds?.forEach((id) => {
    freshIngredientRange?.forEach((range) => {
      if (
        range.lower <= id &&
        range.upper >= id &&
        !checkedIngredients.includes(id)
      ) {
        fresh++;
        checkedIngredients.push(id);
      }
    });
  });
  return fresh;
}

function alreadyProcessed(ranges: FreshIngredient[], value: number): number {
  ranges.forEach((range, idx) => {
    if (range.lower <= value) {
      return idx;
    }
  });
  return -1;
}

function partTwo(freshIngredientRange: FreshIngredient[]) {
  const processedRanges: FreshIngredient[] = [];
  let fresh = 0;

  freshIngredientRange.sort((a, b) => a.lower - b.lower);
  console.log(freshIngredientRange);

  freshIngredientRange.forEach((range) => {
    const index = alreadyProcessed(processedRanges, range.lower);
    if (index != -1) {
      processedRanges[index] = {
        ...processedRanges[index]!,
        upper: range.upper,
      };
    } else {
      processedRanges.push({
        lower: range.lower,
        upper: range.upper,
      });
    }
  });

  processedRanges.forEach((range) => {
    fresh += range.upper - range.lower;
  });

  console.log(processedRanges);

  return fresh;
}

function main() {
  const { freshIngredientRange, ingredientIds } = parseFile("input.txt");

  console.log("Part One: ", partOne(freshIngredientRange!, ingredientIds!));
  console.log("Part Two: ", partTwo(freshIngredientRange!));
}

main();
