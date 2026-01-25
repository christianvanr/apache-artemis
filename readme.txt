4️⃣ Rechten fixen (laatste keer)
sudo chown -R 1000:1000 /volume1/docker/artemis
sudo chmod -R 775 /volume1/docker/artemis

5️⃣ Schoon opnieuw starten
docker rm -f artemis
docker compose up -d


3️⃣ Check of de poort echt luistert
Op de NAS:
docker exec -it artemis ss -tlnp