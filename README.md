# Game-Based VR System for Motor Rehabilitation (EMG-Controlled)

## Overview
This project is a **gamified Virtual Reality (VR) rehabilitation system** that explores the feasibility of **Electromyography (EMG)-controlled interactions** for upper-limb motor training. The system was developed as a **Final Year Project** and serves as a **proof-of-concept** demonstrating real-time EMG integration with Unity-based VR experiences.

The project targets rehabilitation scenarios such as **post-stroke hemiplegia**, where repetitive motor exercises are essential but often suffer from low patient engagement when delivered through traditional physiotherapy methods.

---

## Motivation
Stroke patients with motor impairments require frequent, repetitive training to regain function. However, conventional rehabilitation methods often lead to:
- Low motivation and adherence
- Limited feedback
- Lack of engaging interaction

Virtual Reality offers immersive and engaging environments, but **integrating biosignals such as EMG into standalone VR systems remains technically challenging**. This project investigates whether **gamified VR mechanics combined with EMG input** can provide an engaging and technically viable rehabilitation experience.

---

## Objectives
- Design and implement a **real-time EMG → Unity integration pipeline**
- Develop **gamified VR interactions** driven by muscle activation
- Evaluate **technical feasibility, usability, and engagement**
- Lay groundwork for future **clinical validation and research studies**

---

## System Architecture
The system consists of:
- **EMG Sensors (MyoWare 2.0)** capturing muscle activation
- **Arduino** for signal acquisition and serial transmission
- **Unity Engine** for VR rendering and interaction logic
- **Meta Quest 2** for standalone VR deployment

EMG signals are processed and mapped to in-game actions such as shooting, interaction triggers, and locomotion thresholds.

---

## Game Mechanics
### 1. Zombie Blast
Users follow a glowing butterfly using controlled arm movement. Sustained tracking depletes a zombie’s health, encouraging continuous and precise motor control.

### 2. Elbow Flexer
Users lift their affected limb to reach a configurable EMG threshold, triggering actions such as shooting incoming targets. The threshold can be adjusted to support progressive rehabilitation difficulty.

### 3. Handy Tag
A physics-based locomotion experience using:
- **PID Controllers** for responsive motion
- **Hooke’s Law** for spring-based hand physics  
This mechanic focuses on natural interaction and repeated engagement.

---

## Technical Stack
- **Unity (VR Development)**
- **Meta Quest 2 (Standalone VR)**
- **XR Interaction Toolkit**
- **C# (Interaction logic, physics, controllers)**
- **MyoWare 2.0 EMG Sensors**
- **Arduino**
- **PID Controllers & Spring Physics**

---

### Key Findings
- EMG-based interactions were **intuitive and responsive**
- Participants remained engaged throughout sessions
- Gamified mechanics encouraged sustained repetitive movement

> ⚠️ Note: This study focused on **technical feasibility and engagement**, not clinical efficacy.

---

## Limitations
- No clinical trials with stroke patients
- Small sample size
- EMG calibration varies between users
- Requires professional supervision for therapeutic deployment

---

## Future Work
- Clinical validation with stroke patients under physiotherapist supervision
- Integration of standardized outcome measures (e.g., Fugl-Meyer Assessment)
- Machine Learning–based adaptive difficulty
- Tele-rehabilitation dashboard for remote monitoring
- Longitudinal studies measuring motor improvement

---

## Demo
🎥 **Video Demo:**  
https://youtu.be/cCHkLojpqJM

---

## Author
**Muhammad Ehtesham Safeer**  
XR Developer | Applied XR & Rehabilitation Systems  
📧 Email: ehteshamsafeer@gmail.com  
🔗 LinkedIn: https://www.linkedin.com/in/ehteshamsafeer/

---

## Disclaimer
This project is a **research prototype** and is **not intended for clinical use** without proper medical validation and regulatory approval.
