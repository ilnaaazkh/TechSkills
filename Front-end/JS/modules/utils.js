export async function loadHeader() {
  try {
    const response = await fetch("components/header.html");
    const data = await response.text();
    document.getElementById("header").innerHTML = data;
  } catch (error) {
    console.error("Error loading header:", error);
  }
}

export async function loadMain() {
  try {
    const response = await fetch("components/course-card.html");
    const data = await response.text();
    document.getElementById("main").innerHTML = data;
  } catch (error) {
    console.error("Error loading main content:", error);
  }
}
