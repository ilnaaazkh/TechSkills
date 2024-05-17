import { loadHeader, loadMain } from "./modules/utils.js";
import { getAllCourses } from "./modules/courses.js";

document.addEventListener("DOMContentLoaded", async () => {
  await loadHeader();
  await loadMain();
  getAllCourses();
});
