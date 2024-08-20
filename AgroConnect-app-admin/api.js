//API Templates
let local = false;
let BASE_URL = local ? "https://localhost:7093" : "https://proj.ruppin.ac.il/cgroup64/test2/tar1";

async function create(url, data) {
  try {
    let res = await $.ajax({
      url: `${BASE_URL}/${url}`,
      method: "POST",
      data: JSON.stringify(data),
      contentType: "application/json; charset=UTF-8",
      dataType: "json"
    });

    return res;
  } catch (err) {
    console.error("Error:", err);
    alert("Something went wrong");
    return { status: false, err: err.message };
  }
}

async function read(url) {
  try {
    let res = await $.ajax({
      url: `${BASE_URL}/${url}`,
      method: "GET",
      contentType: "application/json; charset=UTF-8",
      dataType: "json"
    });

    return res;
  } catch (err) {
    console.error("Error:", err);
    return { status: false, err };
  }
}

async function update(url, data) {
  try {
    let res = await $.ajax({
      url: `${BASE_URL}/${url}`,
      method: "PUT",
      data: JSON.stringify(data),
      contentType: "application/json; charset=UTF-8",
      dataType: "json"
    });

    return res;
  } catch (err) {
    console.error("Error:", err);
    alert("Something went wrong");
    return { status: false, err: err.message };
  }
}

async function remove(url) {
  try {
    let res = await $.ajax({
      url: `${BASE_URL}/${url}`,
      method: "DELETE",
      contentType: "application/json; charset=UTF-8",
      dataType: "json"
    });

    console.log("Response:", res);
    return res;
  } catch (err) {
    console.error("Error:", err);
  }
}

async function uploadFile(selectedImage) {
  try {
    let formData = new FormData();
    formData.append("files", selectedImage);

    let res = await $.ajax({
      url: `${BASE_URL}/api/Upload`,
      method: "POST",
      data: formData,
      contentType: false,
      processData: false,
      dataType: "json"
    });

    if (res) {
      return BASE_URL + "/images/" + res;
    } else {
      return false;
    }
  } catch (err) {
    console.error("Error:", err);
    return { status: false, err };
  }
}
