import http from "k6/http";
import { sleep, check } from "k6";

const url = "https://mlchallengemartinlandart.azurewebsites.net";

export let options = {
  stages: [
    { duration: "30s", target: 100 },
    { duration: "1m30s", target: 100 },
    { duration: "20s", target: 0 },
  ],
  thresholds: {
    http_req_duration: ["p(99)<1.500"], // 99% of requests must complete below 1.5s
    "delivered stats successfully": ["p(99)<1.500"], // 99% of requests must complete below 1.5s
  },
};

export default function () {
  let res = http.get(`${url}/api/mutant/stats`);
  check(res, { "status was 200": (r) => r.status == 200 });
  sleep(1);
}
