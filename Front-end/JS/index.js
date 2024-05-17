innerConntainer = document.getElementById("inner");

async function getAllCourses() {
  try {
    const res = await fetch("https://localhost:7046/api/Courses");
    console.log(res);
    if (res.ok) {
      const allCourses = await res.json();
      console.log("курсы", allCourses);
      createCardsWithCourses(allCourses);
    } else {
      console.log("Fuck");
    }
  } catch (error) {
    console.log(error.message);
  }
}

function createCardsWithCourses(courses) {
  courses.forEach((course) => {
    const card = `    
     <div class="card">
      <div class="card-content">
        <div class="card_">${course.title}</div>
        <div class="card_">${course.description}</div>
      </div>
      <div class="btnStartEducation">
        <button>Начать учиться</button>
      </div>
    </div>`;
    innerConntainer.insertAdjacentHTML("beforeend", card);
  });
}

getAllCourses();
