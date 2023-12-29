import sys
import requests
import json

def emotion(Id, Server, Contents, output_file_path='./Assets/8.Data/Test.json'):
    url = "https://naveropenapi.apigw.ntruss.com/sentiment-analysis/v1/analyze"
    
    headers = {
        "X-NCP-APIGW-API-KEY-ID": Id,
        "X-NCP-APIGW-API-KEY": Server,
        "Content-Type": "application/json"
    }
    
    data = {
        "content": Contents
    }

    response = requests.post(url, data=json.dumps(data), headers=headers)
    rescode = response.status_code

    if rescode == 200:
        result_json = response.json()

        # Save the JSON result to a file
        with open(output_file_path, 'w', encoding='utf-8') as json_file:
            json.dump(result_json, json_file, indent=4, ensure_ascii=False)

        print(f"Sentiment result saved to: {output_file_path}")

        print(json.dumps(result_json, indent=4, sort_keys=True))
    else:
        print("Error : " + response.text)

    return response.text

def stt(Id, Server, audio_file_path):
    lang = "Kor"
    url = "https://naveropenapi.apigw.ntruss.com/recog/v1/stt?lang=" + lang

    try:
        with open(audio_file_path, 'rb') as audio_file:
            headers = {
                "X-NCP-APIGW-API-KEY-ID": Id,
                "X-NCP-APIGW-API-KEY": Server,
                "Content-Type": "application/octet-stream"
            }

            response = requests.post(url, data=audio_file, headers=headers)

            rescode = response.status_code

            if rescode == 200:
                print(response.text)
                return response.text
            else:
                print("Error : " + response.text)
                return None

    except FileNotFoundError:
        print(f"Error: File not found at path {audio_file_path}")
        return None

Id = "s5cnwsoc86"
Server = "A1AIG817u9N7svAaqBwuEqqiI5y2wKLfjROagNpo"
audio_file_path = './Assets/8.Data/output.wav'  # Change this to the correct path for your audio file

# Call the STT function
Text = stt(Id, Server, audio_file_path)

# If STT is successful, call the emotion function
if Text:
    Emotion = emotion(Id, Server, Text)
