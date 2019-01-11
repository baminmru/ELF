<?php
	 class C_tpu_def extends CI_Controller {
    function __construct() {
         parent::__construct();
        $this->_loadModels();
    }
    function setRow() {
          log_message('debug', 'TPU_DEF.setRow post : '.json_encode($this->input->post(NULL, FALSE)));
          log_message('debug', 'TPU_DEF.getRows get : '.json_encode($this->input->get(NULL, FALSE)));
          $data = array(
                'tpu_defid' =>  $this->input->get_post('tpu_defid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'issystem' =>   $this->input->get_post('issystem', TRUE)
                ,'theuser' =>   $this->input->get_post('theuser', TRUE)
                ,'thegroup' =>   $this->input->get_post('thegroup', TRUE)
            );
            $tpu_def = $this->m_tpu_def->setRow($data);
            print json_encode($tpu_def);
    }
    function newRow() {
            log_message('debug', 'TPU_DEF.newRow post : '.json_encode($this->input->post(NULL, FALSE)));
          $data = array(
                'tpu_defid' =>  $this->input->get_post('tpu_defid', TRUE)
                ,'instanceid' =>  $this->input->get_post('instanceid', TRUE)
                ,'issystem' =>   $this->input->get_post('issystem', TRUE)
                ,'theuser' =>   $this->input->get_post('theuser', TRUE)
                ,'thegroup' =>   $this->input->get_post('thegroup', TRUE)
            );
                $instanceid =  $this->input->get_post('instanceid', TRUE);
            $tpu_def= $this->m_tpu_def->newRow($instanceid,$data);
            $return = $tpu_def;
            print json_encode($return);
    }
    function getRow() {
        log_message('debug', 'TPU_DEF.getRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $empId  =  $this->input->get_post('id', TRUE);
        if (isset($empId)) {
            $tpu_def = $this->m_tpu_def->getRow($empId);
            $return = array(
                'success' => true,
                'data'    => $tpu_def
            );
            print json_encode($return);
        }
    }
    function getRows() {
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'issystem', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
            $instanceid=$this->input->get('instanceid', FALSE);
            if(isset($instanceid)){
                if($instanceid!=''){
                    $tpu_def= $this->m_tpu_def->getRowsByInstance($instanceid,$sort);
                }else{
                    $tpu_def= $this->m_tpu_def->getRows($sort);
                }
            }else{
              $tpu_def= $this->m_tpu_def->getRows($sort);
            }
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpu_def
            );
        print json_encode($return);
    }
    function getRowsByInstance() {
        log_message('debug', 'TPU_DEF.getRowsByInstance post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'issystem', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $InstId  =  $this->input->get_post('instanceid', TRUE);
        if (strlen($InstId) > 0) {
            $tpu_def= $this->m_tpu_def->getRowsByInstance($InstId,$sort);
            $return = array(
                'success' =>  TRUE ,
                'data'    => $tpu_def
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need instanceid to query.'
            );
        }
        print json_encode($return);
    }
    function getRowsByParent() {
        log_message('debug', 'TPU_DEF.getRowsByParent post : '.json_encode($this->input->post(NULL, FALSE)));
            $group = $this->input->get('group', FALSE); 
           $sort = $this->input->get('sort', FALSE);
           if(!$sort && $group) $sort = $group;
           if(!$sort || $group == $sort) 
            {
            	$sort = json_decode($sort);
            	$sort[] = array('property'=>'issystem', 'direction'=>'ASC');
            	$sort = json_encode($sort);
            }
        $ParentId  =  $this->input->get_post('parentid', TRUE);
        if (strlen($ParentId) > 0) {
            $tpu_def= $this->m_tpu_def->getRowsByParent($ParentId,$sort);
            $return = array(
                'success' => TRUE,
                'data'    => $tpu_def
            );
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'Need parent parentid to query.'
            );
        }
        print json_encode($return);
    }
    function deleteRow() {
        log_message('debug', 'TPU_DEF.deleteRow post : '.json_encode($this->input->post(NULL, FALSE)));
        $tempId  =  $this->input->get_post('tpu_defid', TRUE);
        if (strlen($tempId) > 0) {
            $return = $this->m_tpu_def->deleteRow($tempId);
        }
        else {
            $return = array(
                'success' => FALSE,
                'msg'     => 'No  ID to delete'
            );
        }
        print json_encode($return);
    }
    private function _loadModels () {
        $this->load->model('M_tpu_def', 'm_tpu_def');
    }
}
?>