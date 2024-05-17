export async function getAllCourses() {
  try {
    const res = await fetch("https://localhost:7046/api/Courses");
    if (res.ok) {
      const allCourses = await res.json();
      console.log("курсы", allCourses);
      createCardsWithCourses(allCourses);
    } else {
      console.log("Error fetching courses");
    }
  } catch (error) {
    console.log(error.message);
  }
}

function createCardsWithCourses(courses) {
  const innerContainer = document.getElementById("inner");
  if (!innerContainer) {
    console.error("Inner container not found");
    return;
  }

  courses.forEach((course) => {
    const card = `
        <div class="card">
          <div class="card-content">
            <div class="card_title">${course.title}</div>
            <div class="card_description">${course.description}</div>
          </div>
          <div class="btnStartEducation">
            <button>Начать учиться</button>
          </div>
        </div>`;
    innerContainer.insertAdjacentHTML("beforeend", card);
  });
}
